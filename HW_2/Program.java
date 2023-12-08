package HW_2;

public class Program {
    public static void main(String[] args) {
        
        Builder builder = new ConcreteBuilder();
        Director director = new Director(builder);
        director.construct();
        
        Product product = builder.getResult();
    }
}
