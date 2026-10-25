var builder = DistributedApplication.CreateBuilder(args);



var accomodationDatabaseServer = builder.AddSqlServer("accomodationSqlServer")
    .WithContainerName("bookmyhome-accomodation-sqlserver-dev")
    .WithDataVolume("bookmyhome-accomodationdb-data-dev")
    .WithLifetime(ContainerLifetime.Persistent);

var accomodationDb = accomodationDatabaseServer.AddDatabase("AccomodationDB");

var accomodationService = builder.AddProject<Projects.AccomodationService_Api>("accomodationservice")
    .WithDaprSidecar()
    .WithReference(accomodationDb)
    .WaitFor(accomodationDb);


var bookingDatabaseServer = builder.AddSqlServer("bookingSqlServer")
    .WithContainerName("bookmyhome-booking-sqlserver-dev")
    .WithDataVolume("bookmyhome-bookingdb-data-dev")
    .WithLifetime(ContainerLifetime.Persistent);

var bookingDb = bookingDatabaseServer.AddDatabase("BookingDB");


var bookingService = builder.AddProject<Projects.BookingService_Api>("bookingservice")
    .WithDaprSidecar()
    .WithReference(bookingDb)
    .WaitFor(bookingDb);


var userMySql = builder.AddMySql("userMySql")
    .WithContainerName("bookmyhome-user-mysql-dev")
    .WithDataVolume("bookmyhome-userdb-data-dev")
    .WithLifetime(ContainerLifetime.Persistent);

var userDb = userMySql.AddDatabase("UserDB");

var userService = builder.AddProject<Projects.UserService_Api>("userservice")
    .WithDaprSidecar()
    .WithReference(userDb)
    .WaitFor(userDb);

var reverseProxy = builder.AddProject<Projects.BookMyHome_Yarp>("bookmyhome-yarp")
    .WithReference(accomodationService)
    .WithReference(bookingService)
    .WithReference(userService)
    .WaitFor(accomodationService)
    .WaitFor(bookingService)
    .WaitFor(userService);


var frontend = builder.AddProject<Projects.BookMyHome_Web>("frontend")
    .WithHttpsEndpoint(port: 21007)
    .WithReference(reverseProxy)
    .WaitFor(reverseProxy);





builder.AddProject<Projects.EmailService_Api>("emailservice-api");





builder.Build().Run();
