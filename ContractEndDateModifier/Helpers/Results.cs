namespace ContractEndDateModifier
{
    public static class Results
    {
        public static void Log(string Text)
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Results.txt", DateTime.Now + " - " + Text + Environment.NewLine);
        }
    }
}