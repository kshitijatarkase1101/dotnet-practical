using ServiceCenterManagement.Data;
using ServiceCenterManagement.Models;
using ServiceCenterManagement.Repository;

namespace ServiceCenterManagement.Services
{
    public class InvoiceService : IInvoiceService
    {
        
            private readonly AppDbContext context;

            public InvoiceService(AppDbContext context)
            {
                this.context = context;
            }

            public List<Invoice> GetAll()
            {
                return context.Invoices.ToList();
            }

            public Invoice GetById(int id)
            {
                return context.Invoices.Find(id);
            }

            public void Add(Invoice invoice)
            {
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }

        public void Update(Invoice invoice)
        {
            Invoice existingInvoice =
                context.Invoices.Find(invoice.InvoiceId);

            if (existingInvoice == null)
            {
                throw new Exception("Invoice not found");
            }

            existingInvoice.ServiceRequestId =
                invoice.ServiceRequestId;

            existingInvoice.InvoiceDate =
                invoice.InvoiceDate;

            existingInvoice.LaborCharge =
                invoice.LaborCharge;

            existingInvoice.PartsCharge =
                invoice.PartsCharge;

            existingInvoice.Tax =
                invoice.Tax;

            existingInvoice.Discount =
                invoice.Discount;

            existingInvoice.TotalAmount =
                invoice.TotalAmount;

            existingInvoice.PaymentStatus =
                invoice.PaymentStatus;

            context.SaveChanges();
        }

        public void Delete(int id)
            {
                Invoice invoice = context.Invoices.Find(id);

                if (invoice != null)
                {
                    context.Invoices.Remove(invoice);
                    context.SaveChanges();
                }
            }
        
    }
}

