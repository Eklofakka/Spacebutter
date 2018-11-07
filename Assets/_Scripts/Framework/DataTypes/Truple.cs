public class Truple<T, Y, P>
{
    public T First { get; set; }
    public Y Second { get; set; }
    public P Third { get; set; }

    public Truple(T first, Y second, P third)
    {
        First = first;
        Second = second;
        Third = third;
    }
}
