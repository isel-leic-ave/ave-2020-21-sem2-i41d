public record Student(int Number, string Name, string Classroom) {
    public static Student Parse(string input)
    {
        string[] words = input.Split(';');
        return new Student(int.Parse(words[0]), words[1], words[2]);
    }
}
