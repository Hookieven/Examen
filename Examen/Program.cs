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
    Console.Clear();
    NuevaProvincia = CargaProvincia(); 
    if (NuevaProvincia != null) 
    {
        Provincias.Add(NuevaProvincia);
    }
} while (NuevaProvincia != null);
MostrarDatos();
Resumen();
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
void Resumen() 
{
    int CiudadPoblacion = 0, CiudadSuperficie = 0, ProvinciaPoblacion = 0, ProvinciaSuperficie = 0;
    int cp1 = 0, cp2 = 0;
    int cp = 0, cs = 0, pp = 0, ps = 0;
    foreach (Provincia Provincia in Provincias)
    {
        int x = 0, z = 0;
        foreach (Ciudad Ciudad in Provincia.Ciudades)
        {
            x += Ciudad.Habitantes; pp += x;
            z += Ciudad.Superficie; ps += z;
            if (Ciudad.Habitantes > cp)
            {
                cp = Ciudad.Habitantes;
                cp1 = Provincias.IndexOf(Provincia);
                CiudadPoblacion = Provincia.Ciudades.IndexOf(Ciudad);
            }
            if (Ciudad.Superficie > cs)
            {
                cs = Ciudad.Superficie;
                cp2 = Provincias.IndexOf(Provincia);
                CiudadSuperficie = Provincia.Ciudades.IndexOf(Ciudad);
            }
        }
        if (ps < z)
        {
            ps = z;
            ProvinciaSuperficie = Provincias.IndexOf(Provincia);
        }
        if (pp < x) 
        {
            pp = x;
            ProvinciaPoblacion = Provincias.IndexOf(Provincia);
        }
    }
    Console.WriteLine("--- Resumen Estadistico ---");
    Console.WriteLine($"Ciudad mas poblada: {Provincias[cp1].Ciudades[CiudadPoblacion]} ({Provincias[cp1].Ciudades[CiudadPoblacion].Habitantes} habitantes)");
    Console.WriteLine($"Ciudad con mayor superficie: {Provincias[cp2].Ciudades[CiudadSuperficie]} ({Provincias[cp1].Ciudades[CiudadSuperficie].Superficie} km²)");
    Console.WriteLine($"Provincia más poblada: {Provincias[ProvinciaPoblacion]} ({Provincias[ProvinciaPoblacion]} {pp} habitantes");
    Console.WriteLine($"Provincia con mayor superficie: {Provincias[ProvinciaSuperficie]} ({ps} km²)");
}

