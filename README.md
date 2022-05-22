# WhatsApp-Server

This solution include 2 project:
- API - Its a web service that recevice and sent HTTP request and store the data on a LocalDB.
- WebClient - this part include the React code (inserted using the build command) and the feedback page.

## API (Web Service)

The WebClient is running on MVC:
feedback page- Its the page where you can add a feedback about the website that inculde: username, rating 1-5 and discreption.
to reach this page the user will need to press on the feedback button from the home page of WebClient and to add a new feedback
users press on the create new feedback button.
as mention the feedback site work in MVC platform and we created the feedback modal and controller that uses us to create and
manage the site and we have the view which set the design of the feedback page.
also we added a service intrafce and class which help us interact with the data base in the feedback controller so we dont limit
the usage of site to a specific data base and make him genric.
the site support all the featured requsted in exercise: create, edit, details, delete of a feedback and the average rating appears
in top of the page.
also the site support in search of a feedback by enternig a string containing the username
or description of existing feedback on site.

## Submitting

- Daniel Houri: 314712563
- Dor Huri: 209409218

