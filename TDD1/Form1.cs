namespace TDD1
{
    public partial class Form1 : Form
    {
        public static List<Employee> Employees;


        public Form1()
        {
            InitializeComponent();
        }

        //Button for adding employee manually
        public void OnAddEmployeeBtn(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            if (txtFirstName.Text.All(char.IsDigit) || txtLastName.Text.All(char.IsDigit))
            {
                MessageBox.Show("First-name or Last-name field must contain letters only.");
                txtFirstName.Text = "";
                txtLastName.Text = "";
                return;
            }
            if (!txtSalary.Text.All(char.IsNumber))
            {
                MessageBox.Show("Salary field must contain numbers only.");
                txtSalary.Text = "";
                return;
            }
            if (txtID.Text.All(char.IsLetter))
            {
                MessageBox.Show("ID field must  contain numbers only.");
                txtID.Text = "";
                return;
            }
            item.SubItems.Add(txtLastName.Text);
            item.SubItems.Add(txtFirstName.Text);
            item.SubItems.Add(txtSalary.Text);
            item.SubItems.Add(txtID.Text);
            listViewPeople.Items.Add(item);
            MessageBox.Show("Employee has been successfully added!");
        }
        
        //Tax Rates table for different salaries.
        public int taxRate(double salary)
        {
            if (salary <= 6450)
            {
                return 10;
            }
            if (salary <= 9240)
            {
                return 14;
            }
            if (salary <= 14840)
            {
                return 20;
            }
            if (salary <= 20620)
            {
                return 31;
            }
            if (salary <= 42910)
            {
                return 35;
            }
            if (salary > 42910)
            {
                return 47;
            }
            return 0;    
        }
       
        //Calculates the progressive tax according to the tax rate.
        public double CalcTax(double salary)
        {
            int calcVar = taxRate(salary);
            salary *= calcVar;
            salary /= 100;
            return salary;
        }
       
        //Shows tax calculation in GUI.
        public void OnCalcTaxBtnClicked(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listViewPeople.SelectedItems)
            {
                double sal = double.Parse(listViewPeople.SelectedItems[0].SubItems[2].Text);
                sal = CalcTax(sal);
                txtXXXX.Text = listViewPeople.SelectedItems[0].SubItems[2].Text;
                txtXXXX.Text = sal.ToString();   
            }
        }

        //Exit button for closing the application
        public void OnExitBtn(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Loadidng a list of workers as default
        public void Form1_Load(object sender, EventArgs e)
        {
            Employees = getEmployeeList();
            ViewEmployeeList();
        }

        //Updating the list-view with all changes made
        public void ViewEmployeeList()
        {
            listViewPeople.Items.Clear();
            foreach (var employee in Employees)
            {
                var row = new string[] { employee.firstName, employee.lastName, employee.salary.ToString(), employee.id.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = employee;
                listViewPeople.Items.Add(lvi);
            }
        }

        //Loading employee list out of Employee class constructor / random values
        public List<Employee> getEmployeeList()
        {
            var list = new List<Employee>();
            list.Add(new Employee()
            {
                firstName = "Elidor",
                lastName = "Cohen",
                id = 304717119,
                salary = 6001.45
            });
            list.Add(new Employee() { firstName = "Jonathan", lastName = "Ohana" });


            list.Add(new Employee());
            list.Add(new Employee());



            return list;
        }

        //Initializing 10K random employees
        public void Form2_Load()
        {
            var employees = getTenThousand();
            listViewPeople.Items.Clear();
            foreach (var employee in employees)
            {
                var row = new string[] { employee.firstName, employee.lastName, employee.salary.ToString(), employee.id.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = employee;
                listViewPeople.Items.Add(lvi);
            }
        }

        //A function returning a list of 10K employees
        public List<Employee> getTenThousand()
        {
            var list = new List<Employee>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new Employee());
            }
            return list;
        }

        //Button for clearing an employee information that was entered manually
        public void button5_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtSalary.Clear();
        }

        //Removes an employee out of the list-view
        public void txtRemoveItem_Click(object sender, EventArgs e)
        {
            listViewPeople.Items.Remove(listViewPeople.SelectedItems[0]);
        }

        //Empty function for now
        public void txtXXXX_Click(object sender, EventArgs e)
        {

        }

        //Triggers 10K employees function
        public void addTenThousandBtn_Click(object sender, EventArgs e)
        {
            Form2_Load();
        }

        //Search box - unfinished but working fine
        public void searchBox_TextChanged(object sender, EventArgs e)
        {

            if (searchBox.Text != "")
            {
                for (int i = listViewPeople.Items.Count - 1; i >= 0; i--)
                {
                    var item = listViewPeople.Items[i];
                    if (item.Text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        listViewPeople.Items.Remove(item);
                    }
                }
                if (listViewPeople.SelectedItems.Count == 1)
                {
                    listViewPeople.Focus();
                }
            }
            else
            {
                MessageBox.Show("Search finished!");
            }

        }

        public bool sortCheck()
        {
            for (int j = 1; j<Employees.Count+1; j++)
            {
                if(Employees[j].salary > Employees[j + 1].salary)
                {
                    return true;
                }
            }
            return false;
        }
        //Sort Button for sorting the salaries using BUBBLE SORT (   O(n^2)   ) or QUICK SORT (   O(nlogn)   )
        public void sortSalary_Click(object sender, EventArgs e)
        {
            var x = DateTime.Now;
            var y = DateTime.Now - x;
            
            QuickSort(Employees, 0, Employees.Count - 1); /*Initializing Quick-sort.*/
            //BubbleSort(); /*Uncomment this line to use Bubble-sort function.*/
            ViewEmployeeList(); /*"Demo-refresh for the listview.*/
            MessageBox.Show(string.Format("{0}.{1}", y.Seconds, y.Milliseconds.ToString().PadLeft(3, '0')) + "ms");


        }

        //Bubble-Sort
        public void BubbleSort()
        {
            Employee t;
            for (int j = 0; j <= Employees.Count - 2; j++)
            {
                for (int i = 0; i <= Employees.Count - 2; i++)
                {
                    if (Employees[i].salary < Employees[i + 1].salary)
                    {
                        t = Employees[i + 1];
                        Employees[i + 1] = Employees[i];
                        Employees[i] = t;
                    }
                }
            }
        }

        //Quick-Sort
        public void QuickSort(List<Employee> Employees, int low, int high)
        {
            int i;
            if (low < high)
            {
                i = Partition(Employees, low, high);
                QuickSort(Employees, low, i - 1);
                QuickSort(Employees, i + 1, high);
            }
        }

        //Partition Quick-Sort
        public int Partition(List<Employee> Employees, int low, int high)
        {
            Employee t;
            Employee p = Employees[high];
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (Employees[j].salary > p.salary)
                {
                    i++;
                    t = Employees[i];
                    Employees[i] = Employees[j];
                    Employees[j] = t;
                }
            }
            t = Employees[i + 1];
            Employees[i + 1] = Employees[high];
            Employees[high] = t;
            return i + 1;
        }
    }
}