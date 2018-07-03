using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRYPrinciple_Collections
{
    /*
     * Dec. 17, 2015
     * Book Reading: 97 things Every Programmer Should Know  
     * 
     * Book Chapter: Wet Dilutes Performance Bottlenecks
     * 
     * The importance of the DRY principle (Don’t Repeat Yourself) is that
        it codifies the idea that every piece of knowledge in a system should have a
        singular representation. In other words, knowledge should be contained in
        a single implementation. The antithesis of DRY is WET (Write Every Time).
        Our code is WET when knowledge is codified in several different implementations.
        The performance implications of DRY versus WET become very clear
        when you consider their numerous effects on a performance profile.
     * 
     * There is one use case where we are often guilty of violating DRY: our use of
        collections. A common technique to implement a query would be to iterate
        over the collection and then apply the query in turn to each element:
     * 
     * By exposing this raw collection to clients, we have violated encapsulation. This
        not only limits our ability to refactor, but it also forces users of our code to violate
        DRY by having each of them reimplement potentially the same query. This
        situation can easily be avoided by removing the exposed raw collections from
        the API. In this example, we can introduce a new, domain-specific collective
        type called CustomerList. This new class is more semantically in line with our
        domain. It will act as a natural home for all our queries.
     * 
     * 
     * 
     * 
     */
    public class UsageExample {
        static void Main(string[] args)
        {
        }

        private IList<Customer> allCustomers = new List<Customer>();
        // ...
        public IList<Customer> findCustomersThatSpendAtLeast(Money amount) {
            IList<Customer> customersOfInterest = new List<Customer>();
            foreach (Customer customer in allCustomers) {
                if (customer.spendsAtLeast(amount))
                    customersOfInterest.Add(customer);
            }
            return customersOfInterest;
        }
    }

    public class Customer
    {
        public bool spendsAtLeast(Money amount)
        {
            // do something. 
            return true; 
        }
    }

    public class Money
    {
    }
    /*
    Having this new collection type will also allow us to easily see if these queries
    are a performance bottleneck. By incorporating the queries into the class, we
    eliminate the need to expose representation choices, such as ArrayList, to our
    clients. This gives us the freedom to alter these implementations without fear
    of violating client contracts:
     * */

    public class CustomerList {
        private IList<Customer> customers = new List<Customer>();
        private IList<Customer> customersSortedBySpendingLevel = new List<Customer>();
       
        // ...
        public CustomerList findCustomersThatSpendAtLeast(Money amount) {
            return elementsLargerThan(amount);
        }

        private CustomerList elementsLargerThan(Money amount)
        {
            CustomerList list = new CustomerList();
            // do some 
            return list; 
        }
    }
    
    public class UsageExample_GoodeOne {
            public static void main(String[] args) {
                CustomerList customers = new CustomerList();
                // ...
                Money someMinimalAmount = new Money(); 
                CustomerList customersOfInterest =
                customers.findCustomersThatSpendAtLeast(someMinimalAmount);
                // ...
            }
    }

    /*
     * In this example, adherence to DRY allowed us to introduce an alternate indexing
        scheme with SortedList keyed on our customers’ level of spending. More
        important than the specific details of this particular example, following DRY
        helped us to find and repair a performance bottleneck that would have been
        more difficult to find had the code been WET.
     * 
     */
}
