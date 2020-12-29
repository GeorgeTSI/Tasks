

დავალება - 7 

	ერთი ცხრილის(Teachers) აგების მაგალითი query - ით
	  CREATE TABLE Teachers(
	     Id  INT      NOT NULL,
	     Name nvarchar(50),
	     Surname nvarchar(50),
	     Gender   nvarchar(50), 
	     Subject   nvarchar(50),   
	     PRIMARY KEY (Id)
	  );
	  ბაზაში გავაფორმე პროცედურა GetTeacherByPupilName
	რომელიც დააბრუნებს ყველა მასწავლებელს, რომელიც ასწავლის მოსწავლეს, რომელის სახელია: „გიორგი“ .


 