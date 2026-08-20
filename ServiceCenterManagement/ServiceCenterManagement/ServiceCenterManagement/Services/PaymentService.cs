using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext context;

        public PaymentService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Payment> GetAll()
        {
            return context.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return context.Payments.Find(id);
        }

        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void Update(Payment payment)
        {
            Payment existingPayment =
                context.Payments.Find(payment.PaymentId);

            if (existingPayment == null)
            {
                throw new Exception("Payment not found");
            }

            existingPayment.InvoiceId =
                payment.InvoiceId;

            existingPayment.Amount =
                payment.Amount;

            existingPayment.PaymentDate =
                payment.PaymentDate;

            existingPayment.PaymentMethod =
                payment.PaymentMethod;

            existingPayment.PaymentStatus =
                payment.PaymentStatus;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Payment payment = context.Payments.Find(id);

            if (payment != null)
            {
                context.Payments.Remove(payment);
                context.SaveChanges();
            }
        }
    }
}