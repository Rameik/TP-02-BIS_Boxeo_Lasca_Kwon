bool salir = false;
string nom = " ", pais = "";
int peso = 0, pg = 0, vp = 0, numBox = 0, iq = 0;
double skill1 = 0, skill2 = 0;
Boxeador boxeador1 = new Boxeador(nom, pais, peso, pg, vp, iq);
boxeador1 = null;
Boxeador boxeador2 = new Boxeador(nom, pais, peso, pg, vp, iq);
boxeador2 = null;
do{
Console.Clear();
menu(ref salir, ref nom, ref pais, ref peso, ref pg, ref vp, ref iq, ref numBox, ref skill1, ref skill2, ref boxeador1, ref boxeador2);
Console.WriteLine("Ingrese una tecla para continuar");
Console.ReadKey();
}
while(salir == false);

void menu(ref bool salir, ref string nom, ref string pais, ref int peso, ref int pg, ref int vp, ref int iq, ref int numBox, ref double skill1, ref double skill2, ref Boxeador boxeador1, ref Boxeador boxeador2)
{
    
    int opcion;
    Console.WriteLine("Ingresar opcion entre:");
    Console.WriteLine("1. Cargar Datos Boxeador 1");
    Console.WriteLine("2. Cargar Datos Boxeador 2");
    Console.WriteLine("3. Pelear!");
    Console.WriteLine("4. Cambiar atributos de un boxeador");
    Console.WriteLine("5. Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.Clear();
            numBox = 1;
            if(boxeador1 == null){
                boxeador1 = cargarDatos(ref nom, ref pais, ref peso, ref pg, ref vp, numBox, ref iq);
                skill1 = boxeador1.obtenerSkill();
            }
            else{
                Console.WriteLine("Este boxeador ya fue cargado previamente");
            }
            break;
        case 2: 
            Console.Clear();
            numBox = 2;
            if(boxeador2 == null){
                boxeador2 = cargarDatos(ref nom, ref pais, ref peso, ref pg, ref vp, numBox, ref iq); 
                skill2 = boxeador2.obtenerSkill();
            }
            else{
                Console.WriteLine("Este boxeador ya fue cargado previamente");
            }
            break; 
        case 3: 
        Console.Clear();
        if(boxeador1 != null && boxeador2 != null){
        Pelear(ref skill1, ref skill2, boxeador1, boxeador2);
        }
        else{Console.WriteLine("ERROR. Faltan datos de alguno o de los dos boxeadores");}
        break;
        case 4: 
        Console.Clear();
        cambiarAtributos(boxeador1, boxeador2);
        skill1 = boxeador1.obtenerSkill();
        skill2 = boxeador2.obtenerSkill();
        break;
        case 5: 
        Console.Clear();
        salir = true;
        break;
    }
}

Boxeador cargarDatos(ref string nom, ref string pais, ref int peso, ref int pg, ref int vp, int numBox, ref int iq){
    string eleccion;
    Boxeador Box;
    nom = Funciones.IngresarTexto("Ingrese el nombre del boxeador " + numBox + ": ");
    pais = Funciones.IngresarTexto("Ingrese el pais del boxeador " + numBox + ": ");
    peso = Funciones.IngresarEntero("Ingrese el peso del boxeador " + numBox + ": ");
    iq = Funciones.IngresarEntero("Ingrese la inteligencia del boxeador " + numBox + ": ");
    do{
        Console.WriteLine("Desea ingresar usted mismo la potencia de golpe del boxeador y la velocidad de las piernas? Ingrese 'Si' o 'No'. En caso de que su respuesta sea no, estos valores seran aleatorios");
        eleccion = Console.ReadLine();  
    } while(eleccion != "Si" && eleccion != "No");

    if(eleccion == "Si"){
        pg = 0;
        do{
            pg = Funciones.IngresarEntero("Ingrese la potencia de golpe del boxeador " + numBox + ": ");
        } while(pg < 1 || pg > 100);
        vp = 0;
        do{
            vp = Funciones.IngresarEntero("Ingrese la velocidad de las piernas del boxeador " + numBox + ": ");
        } while(vp < 1 || vp > 100);
        Box = new Boxeador(nom,pais,peso,pg,vp,iq);
    }
    else{
        Box = new Boxeador(nom,pais,peso,0,0,iq);
        Box.atributosAleatorios();
    }
    Console.WriteLine("Se ha creado el boxeador " + nom);
   return Box;
}

void Pelear(ref double skill1, ref double skill2, Boxeador boxeador1, Boxeador boxeador2){
double diferencia1, diferencia2;
diferencia1 = skill1 - skill2;
diferencia2 = skill2 - skill1;
if(diferencia1 >= 30){
Console.WriteLine("Gano " +  boxeador1.Nombre + " por KO");
}
else if(diferencia2 >= 30){
Console.WriteLine("Gano " +  boxeador2.Nombre + " por KO");
}
else if(diferencia1 >= 10 || diferencia1 < 30){
Console.WriteLine("Gano " + boxeador1.Nombre + " por puntos en fallo unanime");
}
else if(diferencia2 >= 10 || diferencia2 < 30){
Console.WriteLine("Gano " + boxeador2.Nombre + " por puntos en fallo unanime");
}
else if(diferencia1 < 10){
    Console.WriteLine("Gano " + boxeador1.Nombre + "por puntos en fallo dividido");
}
else if(diferencia2 < 10){
    Console.WriteLine("Gano " + boxeador2.Nombre + "por puntos en fallo dividido");
}
}

void cambiarAtributos(Boxeador boxeador1, Boxeador boxeador2){

    int numBox, nuevoPg, nuevoVp;
    Console.WriteLine("Ingrese el numero del boxeador que desea cambiar sus atributos");
    numBox = int.Parse(Console.ReadLine());
    do{
    nuevoPg = Funciones.IngresarEntero("Ingrese la nueva potencia de golpe del boxeador " + numBox + ": ");
    }
    while(nuevoPg < 1 || nuevoPg > 100);
    do{
    nuevoVp = Funciones.IngresarEntero("Ingrese la nueva velocidad de las piernas del boxeador " + numBox + ": ");
    }
    while(nuevoVp < 1 || nuevoVp > 100);
    if(numBox == 1) {
    boxeador1.VelocidadPiernas = nuevoVp;
    boxeador1.PotenciaGolpes = nuevoPg;
    }
    if(numBox == 2){
    boxeador2.VelocidadPiernas = nuevoVp;
    boxeador2.PotenciaGolpes = nuevoPg;
    }
}