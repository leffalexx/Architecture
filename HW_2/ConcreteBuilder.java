package HW_2;

class ConcreteBuilder implements Builder {

    private Product product = new Product();

    @Override
    public void buildPartA() {
        product.setPartA(new PartA());  
    }

    @Override
    public void buildPartB() {
        product.setPartB(new PartB());
    }

    @Override
    public void buildPartC() {
        product.setPartC(new PartC());
    }

    @Override
    public Product getResult() {
        return product;
    }
}
