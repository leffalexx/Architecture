public class CarWash implements ExteriorWash, InteriorWash {

    @Override
    public void interiorWash() {
        System.out.println("Мойка интерьера");
    }

    @Override
    public void exteriorWash(CarType carType) {
        switch (carType){
            case Sedan -> System.out.println("Мойка седана");
            case Hatchback -> System.out.println("Мойка хетчбека");
            case Pickup -> System.out.println("Мойка пикапа");
            case Sport -> System.out.println("Мойка спорткара");
        }
    }
}
