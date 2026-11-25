using System.Data;
using Microsoft.Data.SqlClient;

namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
        // Connection string to connect to the SQL Server database
        private readonly string _connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=True;";

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

    }
}
