namespace CharacterCopy
{
    public class TestData
    {
        public static object[] CopyNthOfChars =
        {
           new object[] { new[]{ '\n', 'b' }, new[] { 'a', 'b' }, new[] { 'a', 'b' }, 2, 0},
           new object[] {new[]{ 'a', '\n' }, new[] { 'a', 'b' }, new[] { 'a', 'b' }, 2, 1},
           new object[] {new[]{ 'a', 'b' }, new[] { '\n', 'b' }, new[] { 'a', 'b' }, 2, 1},
           new object[] {new[]{ 'a', 'b' }, new[] { 'a', 'b' }, new[] { '\n', 'b' }, 2, 2},
           new object[] {new[]{ 'a', 'b' }, new[] { 'a', '\n' }, new[] { 'a', 'b' }, 2, 2},
           new object[] {new[]{ 'a', 'b' }, new[] { 'a', 'b' }, new[] { 'a', '\n' }, 2, 3},
           new object[] {new[]{ '\n', 'b', 'c' }, new[] { 'a', 'b', 'c' }, new[] { 'a', 'b', 'c' }, 3, 0},
           new object[] {new[]{ 'a', 'b', '\n' }, new[] { 'a', 'b', 'c' }, new[] { 'a', 'b', 'c' }, 3, 1},
           new object[] {new[]{ 'a', 'b', 'c' }, new[] { '\n', 'b', 'c' }, new[] { 'a', 'b', 'c' }, 3, 1},
           new object[] {new[]{ 'a', 'b', 'c' }, new[] { 'a', 'b', 'c' }, new[] { '\n', 'b', 'c' }, 3, 2},
           new object[] {new[]{ 'a', 'b', 'c' }, new[] { 'a', '\n', 'c' }, new[] { 'a', 'b', 'c' }, 3, 2},
           new object[] { new[] { 'a', 'b', 'c' }, new[] { 'a', 'b', 'c' }, new[] { 'a', 'b', '\n' }, 3, 3}
       };
    }
}