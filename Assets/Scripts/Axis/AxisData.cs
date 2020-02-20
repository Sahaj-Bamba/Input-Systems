[System.Serializable]
public class AxisData
{
    public AxisData(float a,float b){
        horizontal = a;
        vertical = b;
    }
    
    public float horizontal;
    public float vertical;  

    override public string ToString(){
        return " Horizontal : " + horizontal + " /n Vertical : " + vertical;
    } 
}
