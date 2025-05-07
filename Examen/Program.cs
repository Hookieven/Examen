using Examen;

Ciudad CargaCiudad() 
{
    Ciudad Ciudad = new Ciudad();
    Console.WriteLine("Ingrese el Nombre de la ciudad");
    Ciudad.Nombre = Console.ReadLine();
    if (Ciudad.Nombre != string.Empty)
    {
        Console.WriteLine("Ingrese la cantidad de Habitantes que tiene dicha ciudad");
        Ciudad.Habitantes = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la Superficie de la ciudad en km2");
        Ciudad.Superficie = int.Parse(Console.ReadLine());
        return Ciudad;
    }
    else
    {
        return null;
    }
    
}
Provincia CargaProvincia()
{
    Provincia Provincia = new Provincia();
    Console.WriteLine("Ingrese el Nombre de la provincia");
    Provincia.Nombre = Console.ReadLine();
    if (Provincia.Nombre != string.Empty)
    {
        Console.WriteLine("Ingrese quien es el Gobernador");
        Provincia.Gobernador = Console.ReadLine();
        Console.WriteLine("Ingrese a que Region pertenece");
        Provincia.Region = Console.ReadLine();
        Ciudad NuevaCiudad;
        do
        {
            NuevaCiudad = CargaCiudad();
            if (NuevaCiudad != null)
            {
                Provincia.Ciudades.Add(NuevaCiudad);
            }
        } while (NuevaCiudad != null);
        return Provincia;
    }
    else
    {
        return null;
    }
}


List<Provincia> Provincias = new List<Provincia>();
Provincia NuevaProvincia;
do
{
    NuevaProvincia = CargaProvincia();
    if (NuevaProvincia != null) 
    {
        Provincias.Add(NuevaProvincia);
    }
} while (NuevaProvincia != null);
MostrarDatos();
void MostrarDatos()
{
    foreach (Provincia Provincia in Provincias)
    {
        Console.WriteLine("Provincia");
        Console.WriteLine($"  Nombre: {Provincia.Nombre} ");
        Console.WriteLine($"  Gobernador: {Provincia.Gobernador}");
        Console.WriteLine($"  Región: {Provincia.Region}");
        Console.WriteLine("  Ciudades: ");
        foreach (Ciudad Ciudad in Provincia.Ciudades)
        {
            Console.WriteLine($"    Ciudad: {Ciudad.Nombre}");
            Console.WriteLine($"      Habitantes: {Ciudad.Habitantes}");
            Console.WriteLine($"      Superficie: {Ciudad.Superficie}");
        }
    }
}
