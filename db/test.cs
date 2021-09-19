private void connect_DB()
        {
            string query = "SELECT * FROM lots";
            var con = new MySqlConnection("host = s465z7sj4pwhp7fn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;user=b753i7m0218wctsc;password=mmvcw9sv3l1dke2x;database=edrbr8lt4e4qwwe1;port=3306");
            MySqlCommand cmd = new MySqlCommand(query, con);

            
            
          
            try
            {
                MessageBox.Show("Connect");
                con.Open();

                string viewData = "SELECT * FROM lots";
                MySqlDataAdapter adapter = new MySqlDataAdapter(viewData, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

            catch
            {
                MessageBox.Show("Can't connect");
            }



        }
