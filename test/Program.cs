// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

C1 c1 = new C1(3333, "Szopkaa");
 

variable1 example1 = new(3, "dfsffff");

Console.WriteLine(c1.PropB);


Console.WriteLine(example1.cos1);

Console.ReadKey();
public   class C1    
 {
 public C1(int propA, string propB)
  {
        PropA = propA;
        PropB = propB;
  }
    
    public int PropA { get; }
    public string PropB { get; }
}

 
public record variable1(int cos1, string cos2);