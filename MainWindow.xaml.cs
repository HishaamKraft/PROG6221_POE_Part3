using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10276925_PROG6221_POE_Part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Validate validate = new Validate();

        public List<string> recipeNames = new List<string>();
        public Dictionary<string, List<string>> recipeAndIngredients = new Dictionary<string, List<string>>();
        public Dictionary<string, List<double>> recipeAndQuantities = new Dictionary<string, List<double>>();
        public Dictionary<string, List<string>> recipeAndMeasurements = new Dictionary<string, List<string>>();
        public Dictionary<string, List<double>> recipeAndCalories = new Dictionary<string, List<double>>();
        public Dictionary<string, List<string>> recipeAndFoodGroups = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> recipeAndSteps = new Dictionary<string, List<string>>();
        public Dictionary<string, List<double>> originalRecipeAndQuantities = new Dictionary<string, List<double>>();
        public Dictionary<string, List<double>> originalRecipeAndCalories = new Dictionary<string, List<double>>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            navControl.SelectedItem = ScaleRecipe;
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            navControl.SelectedItem = DisplayRecipe;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            navControl.SelectedItem = AddRecipe;
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            navControl.SelectedItem = FilterRecipes;
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = tbRecipeName.Text;

            if (!validate.checkName(recipeName))
            {
                MessageBox.Show("Please enter a valid recipe name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbRecipeName.Clear();
            }
            else
            {
                MessageBox.Show("Recipe name entered successfully.\nContinue to add ingredients and steps for your recipe.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                tbRecipeName.IsEnabled = false;
                btnAddRecipe.IsEnabled = false;
                recipeNames.Add(recipeName);
            }

        }

        public void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            List<string> currentIngredientNames = new List<string>();
            List<double> currentIngredientQuantities = new List<double>();
            List<string> currentIngredientUOMs = new List<string>();
            List<double> currentIngredientCalories = new List<double>();
            List<string> currentIngredientFoodGroups = new List<string>();

            string ingredientName = tbIngredientName.Text;

            if (!validate.checkName(ingredientName))
            {
                MessageBox.Show("Please enter a valid ingredient name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbIngredientName.Clear();
            }
            else
            {
                currentIngredientNames.Add(ingredientName);
            }

            string ingredientQuantity = tbIngredientQuantity.Text;

            if (!validate.checkQuantity(ingredientQuantity))
            {
                MessageBox.Show($"Please enter a valid quantity for {ingredientName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbIngredientQuantity.Clear();
            }
            else
            {
                currentIngredientQuantities.Add(Convert.ToDouble(ingredientQuantity));
            }

            string UoM = "";

            if (cmbUoM.SelectedIndex == -1)
            {
                MessageBox.Show($"Please select a unit of measurement for {ingredientName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                UoM = cmbUoM.SelectedItem.ToString();
                currentIngredientUOMs.Add(UoM);
            }

            string ingredientCalorie = tbIngredientCalorie.Text;

            if (!validate.checkCalories(ingredientCalorie))
            {
                MessageBox.Show($"Please enter a valid calorie amount for {ingredientName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbIngredientCalorie.Clear();
            }
            else
            {
                currentIngredientCalories.Add(Convert.ToDouble(ingredientCalorie));
            }

            string foodGroup = "";

            if (cmbFoodGroup.SelectedIndex == -1)
            {
                MessageBox.Show($"Please select a food group for {ingredientName}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foodGroup = cmbFoodGroup.SelectedItem.ToString();
                currentIngredientFoodGroups.Add(foodGroup);
            }

            tbIngredientName.Clear();
            tbIngredientQuantity.Clear();
            cmbUoM.SelectedIndex = -1;
            tbIngredientCalorie.Clear();
            cmbFoodGroup.SelectedIndex = -1;
        }

        private void btnSteps_Click(object sender, RoutedEventArgs e)
        {
            List<string> currentRecipeSteps = new List<string>();
           
            string step = tbSteps.Text;

            if (step.Equals(""))
            {
                MessageBox.Show("You may not leave the step input field blank", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbSteps.Clear();
            }
            else
            {
                currentRecipeSteps.Add(step);
            }

            lbRecipeSteps.Items.Add(step);
            tbSteps.Clear();

        }

        private void btnDoneAdd_Click(object sender, RoutedEventArgs e)
        {
            navControl.SelectedItem = MenuItems;
        }

        private void btnDisplayRecipes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteRecipes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRecipeDisplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDoneDisplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDoneScale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDoneFilter_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class Validate
    {
        // Method to check that recipe and ingredient names contain only characters and white spaces.
        public bool checkName(string name)
        {
            // Initialize a boolean flag to track if the input name is valid.
            bool valid = true;

            // Loop through each character in the input name.
            foreach (char c in name)
            {
                // Check if the character is a letter or white space.
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c) )
                {
                    // If each charcater is a letter or white space, set the flag to true.
                    valid = false;
                }
            }
            // Return the boolean flag indicating whether the input name is valid.
            return valid;
        }

        // Method to check if a string represents a positive integer.
        public bool IsPositiveInteger(string inputStr)
        {
            // Initialize a boolean flag to track if the input is a positive integer.
            bool isPositiveInteger = false;

            // Try to parse the input string to an integer.
            if (int.TryParse(inputStr, out int result))
            {
                // If parsing is successful, check if the result is greater than 0.
                isPositiveInteger = result > 0;
            }

            // Return the boolean flag indicating whether the input is a positive integer.
            return isPositiveInteger;
        }

        // Method to check if a string represents a valid measurement unit (cup, tablespoon, teaspoon).
        public bool checkMeasurement(string unitMeasurement)
        {
            // Initialize a boolean flag to track if the input unit is valid.
            bool valid = false;

            // Check if the input unit is one of the valid measurement units.
            if (unitMeasurement == "cup" || unitMeasurement == "tablespoon" || unitMeasurement == "teaspoon")
            {
                // If the input unit is valid, set the flag to true.
                valid = true;
            }

            // Return the boolean flag indicating whether the input unit is valid.
            return valid;
        }

        // Method to check if a string represents a valid quantity (positive number).
        public bool checkQuantity(string quantity)
        {
            // Initialize a boolean flag to track if the input quantity is valid.
            bool valid = false;

            // Try to parse the input string to a double.
            if (double.TryParse(quantity, out double result))
            {
                // If parsing is successful, check if the result is greater than 0.
                valid = result > 0;
            }

            // Return the boolean flag indicating whether the input quantity is valid.
            return valid;

        }

        // Method to check if a string represents a valid scaling factor (0.5, 2, or 3).
        public bool checkScale(string scale)
        {
            // Initialize a boolean flag to track if the input scaling factor is valid.
            bool valid = false;

            // Check if the input scaling factor is one of the valid values.
            if (scale.Equals("0.5") || scale.Equals("2") || scale.Equals("3"))
            {
                // If the input scaling factor is valid, set the flag to true.
                valid = true;
            }

            // Return the boolean flag indicating whether the input scaling factor is valid.
            return valid;
        }

        // Method to check if the given food group is valid
        public bool checkFoodGroup(string foodGroup)
        {
            // Initialize a boolean flag to track if the input food group is valid.
            bool valid = false;

            // Check if the food group matches one of the predefined valid groups
            if (foodGroup.Equals("carbohydrate") || foodGroup.Equals("protein") || foodGroup.Equals("dairy") || foodGroup.Equals("vegetable") ||
               foodGroup.Equals("fruit") || foodGroup.Equals("grain") || foodGroup.Equals("fat") || foodGroup.Equals("oil") ||
               foodGroup.Equals("starch") || foodGroup.Equals("water"))
            {
                // If the input food group is valid, set the flag to true.
                valid = true;
            }

            // Return the boolean flag indicating whether the input food group is valid.
            return valid;
        }

        // Method to check if the given calorie value is valid
        public bool checkCalories(string calories)
        {
            // Initialize a boolean flag to track if the input calorie is valid.
            bool valid = false;

            // Try to parse the string as a double
            if (double.TryParse(calories, out double result))
            {
                // If parsing is successful, check if the parsed value is non-negative or equal to 0
                valid = result >= 0;
            }

            //Return the boolean flag indicating whether the input calorie is valid.
            return valid;
        }
    }
}