using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DBTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonImportTableFromCSV_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fileStream = ofd.OpenFile();
            var reader = new StreamReader(fileStream);
            var fileContent = reader.ReadToEnd();

            textBoxInput.Text = fileContent;
        }

        private void buttonFindDependecies_Click(object sender, EventArgs e)
        {
            var dataTable = Utils.CSV2DataTable(textBoxInput.Text);
            if (dataTable == null)
            {
                MessageBox.Show("Input is not properly formatted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var attributeNo = dataTable.Columns.Count;

            var allSubsets = Dependency.GetAllSubsets(attributeNo);

            var dependeciesFunctional = Dependency.GetAllDependeciesFromSubsetList(allSubsets);
            dependeciesFunctional.ForEach(d => d.Type = DependencyType.Functional);

            var dependenciesMultivalued = new List<Dependency>();
            dependenciesMultivalued.AddRange(dependeciesFunctional);
            dependenciesMultivalued.ForEach(d => d.Type = DependencyType.Multivalued);



            var attributeNames = dataTable.GetColumnNames();

            var validFunctionalDependecies = dependeciesFunctional.Where(d => d.IsFunctionalDependency(dataTable)).ToList();

            textBoxFunctional.Text = Dependency.FromDependecyListToString(validFunctionalDependecies, DependencyType.Functional, attributeNames);

            var validMultivaluedDependencies = dependenciesMultivalued.Where(d => d.IsMultivaluedDependency(dataTable)).ToList();

            textBoxMultivalued.Text = Dependency.FromDependecyListToString(validMultivaluedDependencies, DependencyType.Multivalued, attributeNames);

        }

        private void numericUpDowntTextSize_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDowntTextSize.Value <= 0)
                return;
            UpdateTextSizeForTextbox(textBoxInput);
            UpdateTextSizeForTextbox(textBoxFunctional);
            UpdateTextSizeForTextbox(textBoxMultivalued);
        }
        private void UpdateTextSizeForTextbox(TextBox textBox)
        {
            textBox.Font = new Font(textBox.Font.FontFamily, (float)numericUpDowntTextSize.Value);
        }
    }
}
