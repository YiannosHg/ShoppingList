using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class ShoppingList : Form
    {
        public ShoppingList()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int quantity;

            // Check if Name and Quantity entries are valid
            if (String.IsNullOrWhiteSpace(nameTextBox.Text) || String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("You entered an invalid Name or Quantity." + Environment.NewLine + "Please enter valid values", "Invalid Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            // Try to convert Quantity entry into an integer
            try
            {
                quantity = Int32.Parse(quantityTextBox.Text);
            }
            catch 
            {
                MessageBox.Show("You entered an invalid Quantity." + Environment.NewLine + "Please enter a valid value", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            // Create a new ShoppingListEntry to be added in the ListBox
            ShoppingListEntry entry = new ShoppingListEntry(nameTextBox.Text, quantity);

            // Add new ShoppingListEntry in the ListBox and increase completedProgressBar maximum property
            todoListBox.Items.Add(entry);
            ++completedProgressBar.Maximum;

            // Clear entries from the textBoxes
            nameTextBox.Clear();
            quantityTextBox.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Get the entry that will be deleted from todoListBox
            var selectedEntry = todoListBox.SelectedItem;

            if (selectedEntry != null)
            {
                // Remove the entry and decrease completedProgressBar maximun property
                todoListBox.Items.Remove(selectedEntry);
                --completedProgressBar.Maximum;
            }
        }

        private void markAsCompleteButton_Click(object sender, EventArgs e)
        {
            // Get the entry that will be moved to completed todoListBox
            var selectedEntry = todoListBox.SelectedItem;

            if (selectedEntry != null)
            {
                // Remove the entry from todoListBox and add it to completedListBox
                todoListBox.Items.Remove(selectedEntry); 
                completedListBox.Items.Add(selectedEntry);
                // Change completedProgressBar value property
                ++completedProgressBar.Value;
            }
        }
      
        private void clearButton_Click(object sender, EventArgs e)
        {
            // Remove all items from completedListBox and change completedProgressBar maximum and value properties
            completedListBox.Items.Clear();
            completedProgressBar.Maximum -= completedProgressBar.Value;
            completedProgressBar.Value = 0;
        }
    }
}
