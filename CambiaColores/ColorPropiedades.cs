namespace CambiaColores;
public static class ColorPropiedades{

    public static string ColorToHex(int red, int green, int blue){
        return $"#{red:X2}{green:X2}{blue:X2}";
    }

    public static (int red, int green, int blue) RandomColor(){
        Random random = new Random();
        int red = random.Next(256);
        int green = random.Next(256);
        int blue = random.Next(256);
        
        return(red , green,blue);
    }
}