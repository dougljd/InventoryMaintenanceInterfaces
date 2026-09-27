using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        private InvItemList invItems = new InvItemList();

        // Jonathan Douglas
        public frmInvMaint()
        {
            InitializeComponent();

            // Changes the title displayed at the top of the form
            this.Text = "Jonathan Douglas's Inventory Maintenance";
        }

        // Jonathan Douglas
        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            invItems.Changed += new InvItemList.ChangeHandler(HandleChange);
            invItems.Fill();
            FillItemListBox();
        }

        // Jonathan Douglas
        private void FillItemListBox()
        {
            InvItem item;
            lstItems.Items.Clear();

            for (int i = 0; i < invItems.Count; i++)
            {
                item = invItems[i];
                lstItems.Items.Add(item.GetDisplayText());
            }
        }

        // Jonathan Douglas
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewItem newItemForm = new frmNewItem();
            InvItem invItem = newItemForm.GetNewItem();

            if (invItem != null)
            {
                Debug.WriteLine($"Item type: {invItem.GetType()}");
                Debug.WriteLine($"Item is InvItem: {invItem is InvItem}");
                Debug.WriteLine($"Item is IDisplayable: {invItem is IDisplayable}");

                invItems += invItem;
            }
        }

        // Jonathan Douglas
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;

            if (i != -1)
            {
                InvItem invItem = invItems[i];

                string message = "Are you sure you want to delete "
                    + invItem.Description + "?";

                DialogResult button =
                    MessageBox.Show(
                        message,
                        "Confirm Delete",
                        MessageBoxButtons.YesNo);

                if (button == DialogResult.Yes)
                {
                    invItems -= invItem;
                }
            }
        }

        // Jonathan Douglas
        private void HandleChange(InvItemList invItems)
        {
            invItems.Save();
            FillItemListBox();
        }

        // Jonathan Douglas
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}