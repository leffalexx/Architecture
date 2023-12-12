
public class Program {


    public static void main(String[] args) {
        SportCar car01SportCar = SportCar.create("Porsche", "911", Color.BLACK, 4);
        Sedan car02Sedan = Sedan.create("Tesla", "Model 3", Color.BLACK, 4);
        CarWash CarWash = new CarWash();
        RefuelingStation refuelingStation = new RefuelingStation();

        car01SportCar.setCarWash(CarWash);
        car01SportCar.setRefuelingStation(refuelingStation);
        car02Sedan.setCarWash(CarWash);
        car02Sedan.setRefuelingStation(refuelingStation);

        car01SportCar.fuel();
        car01SportCar.exteriorWash();
        car02Sedan.fuel();
        car02Sedan.exteriorWash();
    }
}
