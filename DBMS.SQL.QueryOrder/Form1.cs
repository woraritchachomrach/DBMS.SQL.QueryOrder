using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SQL.QueryOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connectDB()
        {
            string server = @"DESKTOP-O6L6M1G\SQLEXPRESS";
            string db = "northwind";
            string strCon = string.Format(@"Data Source={0};Initial Catalog={1};"
                            + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnectDB()
        {
            conn.Close();
        }

        private void showdata(string sql, DataGridView dgv)
        {
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgv.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectDB();
            string sqlQuery = "SELECT \r\n    o.OrderID AS \"รหัสใบสั่งซื้อ\",\r\n    o.OrderDate AS \"วันที่ออกใบสั่งซื้อ\",\r\n    o.RequiredDate AS \"วันที่รับสินค้า\",\r\n    s.CompanyName AS \"ชื่อบริษัทขนส่ง\",\r\n    e.FirstName + ' ' + e.LastName AS \"ชื่อเต็มพนักงาน\",\r\n    c.CompanyName AS \"ชื่อบริษัทลูกค้า\",\r\n    c.Phone AS \"เบอร์โทรลูกค้า\",\r\n    CAST(SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS DECIMAL(18, 2)) AS \"ยอดเงินรวม\"\r\nFROM \r\n    Orders o\r\nJOIN \r\n    [Order Details] od \r\n    ON o.OrderID = od.OrderID\r\nJOIN \r\n    Shippers s \r\n    ON o.ShipVia = s.ShipperID\r\nJOIN \r\n    Employees e \r\n    ON o.EmployeeID = e.EmployeeID\r\nJOIN \r\n    Customers c \r\n    ON o.CustomerID = c.CustomerID GROUP BY \r\n    o.OrderID, o.OrderDate, o.RequiredDate, s.CompanyName, e.FirstName, e.LastName, c.CompanyName, c.Phone;";

            showdata(sqlQuery, dgvOrders);
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
                string sqlQuery = "SELECT \r\n    p.ProductID AS \"รหัสสินค้า\",\r\n    p.ProductName AS \"ชื่อสินค้า\",\r\n    od.Quantity AS \"จำนวนที่ขายได้\",\r\n    od.UnitPrice AS \"ราคาที่ขาย\",\r\n    od.Discount * 100 AS \"ส่วนลด(%)\",\r\n    (od.Quantity * od.UnitPrice) AS \"ยอดเงินเต็ม\",\r\n    (od.Quantity * od.UnitPrice * od.Discount) AS \"ยอดเงินส่วนลด\",\r\n    (od.Quantity * od.UnitPrice * (1 - od.Discount)) AS \"ยอดเงินที่หักส่วนลด\"\r\nFROM \r\n    [Order Details] od\r\nJOIN \r\n    Products p \r\n    ON od.ProductID = p.ProductID\r\nWHERE \r\n    od.OrderID = @id";
                cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvDetails.DataSource = ds.Tables[0];
            }
        }
    }
}
