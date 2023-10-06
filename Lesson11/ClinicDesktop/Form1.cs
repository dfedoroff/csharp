using ClinicServiceNamespace;

namespace ClinicDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5076", new HttpClient());
            ICollection<Client> clients = clinicClient.ClientGetAllAsync().Result;

            listViewClients.Items.Clear();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = client.SurName });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = client.FirstName });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = client.Patronymic });
                listViewClients.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5076", new HttpClient());
            CreateClientRequest request = new CreateClientRequest
            {
                Document = documentBox.Text,
                SurName = surnameBox.Text,
                FirstName = firstNameBox.Text,
                Patronymic = patronymicBox.Text,
                Birthday = DateTime.Parse(birthdayBox.Text)
            };

            clinicClient.ClientCreateAsync(request);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClinicClient clinicClient = new ClinicClient("http://localhost:5076", new HttpClient());
            ListViewItem focusedItem = listViewClients.FocusedItem;
            if (focusedItem != null)
            {
                clinicClient.ClientDeleteAsync(Convert.ToInt32(focusedItem.Text));
                listViewClients.Items.Remove(focusedItem);
            }
        }
    }
}
