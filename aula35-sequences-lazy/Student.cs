public record Student(int Number, string Name, string Classroom) {
    public static Student Parse(object input)
    {
        string[] words = ((string)input).Split(';');
        return new Student(int.Parse(words[0]), words[1], words[2]);
    }
}
