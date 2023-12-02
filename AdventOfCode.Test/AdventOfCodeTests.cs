using AdventOfCode.Days;

namespace AdventOfCode.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(GetAllTestCases))]
        public void Test_All_Days(IDailyExercise exercise)
        {
            var inputText = File.ReadAllText($"Days/Day_{exercise.Day}/Input.txt");

            Assert.Multiple(() =>
            {
                Assert.That(exercise.ExpectedResult, Is.Not.Null);
                Assert.That(exercise.Run(inputText), Is.EqualTo(exercise.ExpectedResult));
            });
        }

        private static IEnumerable<IDailyExercise> GetAllTestCases()
        {
            var types = typeof(IDailyExercise).Assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(IDailyExercise)) && t != typeof(IDailyExercise));
            var days = types.Select(Activator.CreateInstance).Cast<IDailyExercise>();

            return days;
        }
    }
}