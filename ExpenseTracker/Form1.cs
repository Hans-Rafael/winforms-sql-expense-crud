using System.Data;
using Microsoft.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
        // Connection string to connect to the SQL Server database
        private readonly string _connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        private int _selectedId = 0; // <-- Esta línea es la que guarda el Id de la fila seleccionada

        public Form1()
        { // Constructor que inicializa el formulario y sus componentes
            InitializeComponent();
        }
        // Método para cargar los gastos desde la base de datos y mostrarlos en el DataGridView
        private void LoadExpenses(string search = "")
        {
            using var conn = new SqlConnection(_connectionString);
            string query = @"
                SELECT Id, Description, Category, Amount, ExpenseDate, IsPaid
                FROM Expenses
                WHERE Description LIKE @Search
                ORDER BY ExpenseDate DESC, Id DESC;";

            using var cmd = new SqlCommand(query, conn);// Crear un comando SQL para seleccionar los gastos filtrados por descripción
            cmd.Parameters.AddWithValue("@Search", $"%{search}%");

            using var adapter = new SqlDataAdapter(cmd);// Crear un adaptador de datos para llenar un DataTable con los resultados de la consulta
            var table = new DataTable();// Crear un DataTable para almacenar los resultados de la consulta
            adapter.Fill(table);

            dgvExpenses.DataSource = table;// Asignar el DataTable como fuente de datos del DataGridView

            // Calcular el total sumando la columna Amount
            decimal total = 0;
            foreach (DataRow row in table.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
            }
            lblTotal.Text = $"Total: {total:C2}";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox desde código
            cboCategory.Items.AddRange(new string[]
            {
                "Food", "Transport", "Utilities", "Entertainment", "Other"
            });
            cboCategory.SelectedIndex = 0;
            //Abajo se llama al método LoadExpenses para cargar los gastos existentes desde la base de datos al iniciar el formulario
            LoadExpenses();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))// Validar que la descripción no esté vacía
            {
                MessageBox.Show("Please enter a description.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            if (numAmount.Value <= 0)// Validar que el monto sea mayor que cero
            {
                MessageBox.Show("Amount must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmount.Focus();
                return;
            }

            using var conn = new SqlConnection(_connectionString);// Crear una conexión a la base de datos
            string query = @"
        INSERT INTO Expenses (Description, Category, Amount, ExpenseDate, IsPaid)
        VALUES (@Description, @Category, @Amount, @ExpenseDate, @IsPaid);";

            using var cmd = new SqlCommand(query, conn);// Crear un comando SQL para insertar un nuevo gasto en la base de datos
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());// Agregar parámetros al comando SQL para evitar inyecciones SQL
            cmd.Parameters.AddWithValue("@Category", cboCategory.SelectedItem?.ToString() ?? "Other");
            cmd.Parameters.AddWithValue("@Amount", numAmount.Value);
            cmd.Parameters.AddWithValue("@ExpenseDate", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@IsPaid", chkPaid.Checked);

            conn.Open();// Abrir la conexión a la base de datos
            cmd.ExecuteNonQuery();

            LoadExpenses(txtSearch.Text.Trim());// Recargar los gastos después de guardar uno nuevo
            ClearForm();// Limpiar el formulario después de guardar un gasto
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            _selectedId = 0;
            txtDescription.Clear();
            cboCategory.SelectedIndex = 0;
            numAmount.Value = 0;
            dtpDate.Value = DateTime.Today;
            chkPaid.Checked = true;
            txtDescription.Focus();
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evita errores si el usuario hace clic en el encabezado de la tabla
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvExpenses.Rows[e.RowIndex];

            _selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            cboCategory.SelectedItem = row.Cells["Category"].Value?.ToString();
            numAmount.Value = Convert.ToDecimal(row.Cells["Amount"].Value);
            dtpDate.Value = Convert.ToDateTime(row.Cells["ExpenseDate"].Value);
            chkPaid.Checked = Convert.ToBoolean(row.Cells["IsPaid"].Value);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Please select an expense from the table first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text) || numAmount.Value <= 0)
            {
                MessageBox.Show("Please enter a valid description and an amount greater than zero.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var conn = new SqlConnection(_connectionString);
            string query = @"
        UPDATE Expenses
        SET Description = @Description,
            Category = @Category,
            Amount = @Amount,
            ExpenseDate = @ExpenseDate,
            IsPaid = @IsPaid
        WHERE Id = @Id;";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", _selectedId);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@Category", cboCategory.SelectedItem?.ToString() ?? "Other");
            cmd.Parameters.AddWithValue("@Amount", numAmount.Value);
            cmd.Parameters.AddWithValue("@ExpenseDate", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@IsPaid", chkPaid.Checked);

            conn.Open();
            cmd.ExecuteNonQuery();

            LoadExpenses(txtSearch.Text.Trim());
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId == 0)
            {
                MessageBox.Show("Please select an expense from the table first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this expense?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using var conn = new SqlConnection(_connectionString);
            string query = "DELETE FROM Expenses WHERE Id = @Id;";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", _selectedId);

            conn.Open();
            cmd.ExecuteNonQuery();

            LoadExpenses(txtSearch.Text.Trim());
            ClearForm();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadExpenses(txtSearch.Text.Trim());
        }
    }
}
