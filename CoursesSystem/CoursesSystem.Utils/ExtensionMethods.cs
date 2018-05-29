namespace CoursesSystem.Utils
{
    public static class ExtensionMethods
    {
        public static string UppercaseFirstLetter(this string value)
        {
            // Uppercase the first letter in the string.
            if (value.Length > 0)
            {
                char[] array = value.Trim().ToCharArray();

                if (char.IsLetter(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                    return new string(array);
                }
            }

            return value;
        }
    }
}
