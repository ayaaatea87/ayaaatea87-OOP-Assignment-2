using SrpLab;

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor Done)");
Console.WriteLine("=================================================");

// Ward
var ward = new WardBoard();
ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
Console.WriteLine(ward.BuildHandoffNote(1));
Console.WriteLine(string.Join(" | ", ward.DrainPagerLog()));


// Checkout Basket
var basket = new CheckoutBasket();
basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
Console.WriteLine(
    $"basket total={basket.GrandTotal()} auth={basket.AuthorizePaymentStub("4242")}");


// Support Ticket
var ticket = new SupportTicket(
    "T-1",
    "cannot login",
    "prod is down for me",
    DateTimeOffset.UtcNow);

var priorityAnalyzer = new TicketPriorityAnalyzer();

ticket.SetPriority(
    priorityAnalyzer.CalculatePriority(
        ticket.Subject,
        ticket.Body));

var ticketSla = new TicketSlaService();

Console.WriteLine(
    ticketSla.DraftPublicReply(ticket, "Nora"));


// Loan
var loan = new LoanDesk(
    60_000m,
    640,
    4,
    hasCollateral: false);

var loanOutput = new LoanOutput();

Console.WriteLine(
    loanOutput.DecisionLetter(loan, "Omar"));


// Course Enrollment
var course = new CourseEnrollmentDesk(
    "SEF-101",
    capacity: 1,
    tuition: 3000m);

Console.WriteLine(course.Register("a@mail.com"));
Console.WriteLine(course.Register("b@mail.com"));

var welcomePacket = new CourseWelcomePacket();

Console.WriteLine(
    welcomePacket.Generate(
        course,
        "b@mail.com",
        "Bea"));


// Kitchen
var kitchen = new KitchenTicket();

kitchen.AddItem(
    "Pasta",
    new[] { "wheat", "milk" },
    12);

var kitchenOperations = new KitchenOperations();
var kitchenPrinter = new KitchenTicketPrinter();

Console.WriteLine(
    kitchenPrinter.RenderThermalTicket(
        kitchen,
        kitchenOperations,
        42));


// Subscription
var sub = new SubscriptionBilling(
    "c-9",
    99m,
    new DateOnly(2026, 9, 1),
    new DateOnly(2026, 10, 1));

sub.RegisterFailedPayment();

var proration = new SubscriptionProration();
var billingOutput = new SubscriptionOutput();

Console.WriteLine(
    billingOutput.DunningEmail(
        sub,
        proration,
        "Sara",
        new DateOnly(2026, 9, 20)));


// Warehouse Pick List
var pick = new WarehousePickList();

pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);

var pickOutput = new PickListOutput();

Console.WriteLine(
    pickOutput.PickerScript(pick));


// Grade Book
var grades = new GradeBook();

grades.Record("s1", 92);
grades.Record("s1", 88);

var gradePolicy = new GradePolicy();
var transcriptExporter = new Transcript();

Console.WriteLine(
    transcriptExporter.TranscriptPlain(
        grades,
        gradePolicy,
        "s1",
        "Ali"));


// Appointment
var appt = new AppointmentScheduler(
    new TimeOnly(9, 0),
    new TimeOnly(17, 0),
    30);

var slot = appt.FindNextSlot(
    DateTimeOffset.Parse("2026-09-21T08:00:00Z"),
    48);

if (slot is null)
    throw new InvalidOperationException("no slot");

appt.TryBook(slot.Value);

var reminder = new AppointmentReminder();

Console.WriteLine(
    reminder.CreateSms(
        slot.Value,
        "0100"));

Console.WriteLine(
    "Done. Now split responsibilities — without breaking behavior.");