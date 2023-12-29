package ru.geekbrains.lesson8.models;

import ru.geekbrains.lesson8.presenters.Model;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

public class TableService implements Model {

    private Collection<Table> tables;

    @Override
    public Collection<Table> loadTables() {
        if (tables == null) {
            tables = new ArrayList<>();

            tables.add(new Table());
            tables.add(new Table());
            tables.add(new Table());
            tables.add(new Table());
            tables.add(new Table());
        }

        return tables;
    }

    @Override
    public int reservationTable(Date reservationDate, int tableNo, String name) {

        for (Table table : tables) {
            if (table.getNo() == tableNo) {
                Reservation reservation = new Reservation(table, reservationDate, name);
                table.getReservations().add(reservation);
                return reservation.getId();
            }
        }
        throw new RuntimeException("Некорректный номер столика");
    }

    @Override
    public int changeReservationTable(int oldReservationId, Date reservationDate, int newTableNo, String name) {

        for (Table table : tables) {
            for (Reservation r : table.getReservations()) {
                if (r.getId() == oldReservationId) {

                    for (Table newTable : tables) {
                        if (newTable.getNo() == newTableNo) {

                            Reservation newReservation = new Reservation(newTable, reservationDate, name);
                            newTable.getReservations().add(newReservation);

                            return newReservation.getId();
                        }
                    }

                    throw new RuntimeException("Столик с номером " + newTableNo + " не найден");
                }
            }
        }

        throw new RuntimeException("Резервирование с id " + oldReservationId + " не найдено");
    }
}
