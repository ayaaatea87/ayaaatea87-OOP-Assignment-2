## WardBoard
1- مسئول عن ادارة المرضي 
ربط المريض بسرير معين 
2- تحديد درجة خطورة الحالة من خلال حساب heartRate وSpO2 
3- بيعمل HANDOFF NOTES  تعريض ملخص بتفاصيل حالة المريض 
4- لو درجة الخطورة عالية بيضيفها في pager log 
5- فايل csv بيحفظ الداتا فى 
## problem in this class : 
multiple responsibilities in one class 
 acuity مثلا التغيير في طريقة حساب ال 
 format handnotes تغير ال 
 تغيير طريقة CSV
 تغيير نظام ال pager

 ## CheckoutBasket
 1- حساب المنتجات قبل الخصم 
 2- حساب السعر بعد ال coupon 
 3- اضافة سعر التغليف على الاجمالى
 4- Creating the gift message
 5- Authorizing payment
 ## problem in this class : 
 طريقة حساب الكوبون ممكن تتغير حسب الbusiness policy 
 التغيير في طريقة الدفع
 gift message التغيير فى طريقة كتابة 
 كل ميثود فيهم ليها دور منفصل والتغير فيه هيؤدي الى التغير في نفس الكلاس 

 ## SupportTicket
 1- calculate priority from text 
 2- calculate deadline
 3- create customer reply 
 4- create internal escalation messages
 5- manage support tickets
 ## problem in this class : 
التغيير في حساب priority حسب business policy
 customer reply التغيير في فورمات 
 SLA التغيير في حساب 
 internal message فورمات برضو ال 
 اي تغيير في اي وقت هعدل في نفس الكلاس 
 
 ## loanDesk
 1- calculate risk score and determine loan eligibility
 2- determine required documents
 3- write decision letters
 4- underwriter CSV data

 ## CourseEnrollmentDesk
 1-  manage enroll course , waiting list , capacity
 2- generate welcome packet 
 3- manage invoice line 
  ## problem in this class :
  تغير شكل رسالة الترحيب 
  تغير فورمات الفاتورة 
  تغير waiting list policy  

 ## gradeBook 
 1- manage student scores and calculate averages
 2- apply academic grading and honor policy
 3- generate student transcripts
 4- grade data as CSV
  ## problem in this class :
   policy for calculate grading or honor تغير 
   transcriptفورمات ال 

 ## appointmentDesk 
 1- manage appointment scheduling and business hours
 2- generate ics calendar data
 3- generate sms appointment reminders

 ## kitchenTickets 
 1- manage kitchen order items
 2- detect allergens from ingredients
 3- calculate ETA and kitchen lane
 4- print kitchen ticket

 ## subscriptionBilling
1- calculate subscription billing
2- generate invoice numbers
3- manage failed payments , dunning emails
4- generate accounting ledger data

## wareHousePickList
1-manage stock needs and allocate available inventory
2-the warehouse walking order
3-picker instructions and shortage warnings
4- WMS XML data

تغير walkingOrder() لو طريقة التخزين اتغيرت 
ممكن فورمات WMS تتغير 