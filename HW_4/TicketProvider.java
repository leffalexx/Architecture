import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

public class TicketProvider {

    private final Database database;
    private final PaymentProvider paymentProvider;

    public TicketProvider(
            Database database,
            PaymentProvider paymentProvider
    ){
        this.database = database;
        this.paymentProvider = paymentProvider;
    }

    public Collection<Ticket> searchTicket(int clientId, Date date){
//Предусловие:
        if (clientId < 0) {
            throw new IllegalArgumentException("clientId добжен быть больше 0!");
        }

        Collection<Ticket> tickets = new ArrayList<>();
        for (Ticket ticket: database.getTickets()) {
            if (ticket.getCustomerId() == clientId && ticket.getDate().equals(date))
                tickets.add(ticket);
        }
        return tickets;
    }

    public boolean buyTicket(int clientId, String cardNo){
//Предусловие:
        if (clientId < 0) {
            throw new IllegalArgumentException("clientId добжен быть больше 0!"); 
        }
        
        if (cardNo == null || !isValidCardNoFormat(cardNo)) {
            throw new IllegalArgumentException("Некорректный номер карты");
        }

        int orderId = database.createTicketOrder(clientId);
        double amount = database.getTicketAmount();
        return paymentProvider.buyTicket(orderId,  cardNo, amount);

    }

    private boolean isValidCardNoFormat(String cardNo) {
//Проверяем корректность формы номера карты
        return true;
    }

    public boolean checkTicket(String qrcode){
//Предусловие:
        if (qrcode == null) {
            throw new IllegalArgumentException("Ошибка QR-кода!");
        }

        for (Ticket ticket: database.getTickets()) {
            if (ticket.getQrcode().equals(qrcode)){
                ticket.setEnable(false);
                // Save database ...
                return true;
            }
        }
        return false;
    }
}
