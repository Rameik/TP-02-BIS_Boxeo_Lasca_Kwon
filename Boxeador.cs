public class Boxeador{

public string Nombre {get;set;}
public string Pais {get;set;}
public int Peso {get;set;}
public int PotenciaGolpes {get;set;}
public int VelocidadPiernas {get;set;}

public int Inteligencia {get;set;}
public Boxeador(){


}

public Boxeador(string nom, string pais, int peso, int pg, int vp, int iq){
Nombre = nom;
Pais = pais;
Peso = peso;
PotenciaGolpes = pg;
VelocidadPiernas = vp;
Inteligencia = iq;

}


public double obtenerSkill(){

double skill = 0;
Random aleatorio = new Random();
int azar = aleatorio.Next(1,10);

skill += (VelocidadPiernas * 0.6);
skill += (PotenciaGolpes * 0.8);
skill += (Inteligencia * 0.25);
skill += azar;

return skill;
}
public void atributosAleatorios(){
Random aleatorio = new Random();
VelocidadPiernas = aleatorio.Next(1,100);
PotenciaGolpes = aleatorio.Next(1,100);

}
}

