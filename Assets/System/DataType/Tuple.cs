﻿public class Tuple <T, Y>
{
    public T First { get; set; }
    public Y Second { get; set; }

    public Tuple( T first, Y second )
    {
        First = first;
        Second = second;
    }
}
