namespace Application.Products.Commands
{
    public static class InsertProductCommandValidator
    {
        public static bool IsValid(this InsertProductCommand model, out string validationMessage)
        {
            validationMessage = string.Empty;
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                validationMessage += "Name is required.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(model.SerialNumber))
            {
                validationMessage += "SerialNumber is required.";
                isValid = false;
            }

            return isValid;
        }
    }
}