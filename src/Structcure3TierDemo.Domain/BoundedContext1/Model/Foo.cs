namespace Structure3TierDemo.Domain.BoundedContext1.Model
{
    public class Foo
    {
        private int _count;

        public string Id { get; set; }

        public string Message => $"I did the thing {_count} times!";

        public void DoThing()
        {
            _count++;
        }
    }
}
