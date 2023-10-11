# Lab-5-2910
## Errors encounters
1. One of the first issues I encountered was how and what classes I would make.
     - I resolved this by first closely examining what I intended to allow the user to have. Next, also figured out what classes were inside of the other ones. Finally, I called them as a property in the class they were in, which enabled me to take out what was unnecessary in the process. 
   
2. The client had many options to choose from and I needed more than one different type of request link.
    - I resolved this by using my diagram to choose what each method would do, based on where it was called. Next, I had to make many client request methods.
    - Example: The await NoExclusion() and await Exlcusion() method.
      
3. Once I started to make my second client request, I realized I had to figure out a way to enable the link to adapt to what the user chooses to do.
    - I resolved this by realizing that I needed what I call a "global" link. Essentially, a link (in this case a string) that will be accessed in any method in the program. NOTE: IN THE PROGRAM THE STRING NAMED "GlobalHttp" WAS WHEN I FIRST REALIZED THIS. IT DOES NOT SERVE THE PURPOSE THAT I NEEDED IT TO SERVE AS LATER. THIS LEAD ME TO MY NEXT ISSUE:
    - ISSUE: THE LINK NEEDED TO BE ADDED THINGS THAT ARE SITUATIONAL (the example below explains). I truly resolved this by creating another public static string named "UserHttp". I realized that this string will hold the current link that the user is "building" throughout the program.
    - Example: If the user chooses to exclude something (that is not gender) and wants to specify the parameters for gender, the link would have to be added "&&gender=" after the last method. However, if the user did not exclude anything and wants to specify gender, then the link would have to added "?gender=" after the last method.

4. Alongside the issue above, once I created "UserHttp", I needed a way to figure out when to add "&&" or "?" to it.
    - I resolved this by counting the length of the string in the "GlobalHttp". This aided in knowing if it surpassed 30, then other methods had been called upon and would need "??". On the other side, if the length was exactly 30, then the user did not want any previous options (no methods were called) and it needed "?".
    - Example: await SpecifyGender() and await SpecifyNationality() shows what this is talking about. The other request methods changed and I will example further below.

5. I jumped around when doing the client request methods, so the next issue I got to was figuring out how I was going to call the methods that parameterized based on what the user had not excluded previously.
    - I resolved this by doing a "Contains" on the list I had made that had the options the user could choose to request (line 175 in the program). To further explain, there are three parameterizable options available and some (like the password) should not be parameterized if the user has chosen to exclude login. Moreover, if the user had chosen to exclude all three parameterizable available, then it should not be called. It would go on to "await RetrievingMoreThanOne()". 
    - Example: If the user chooses to exclude gender, the SpecifyGender() could not be requested.

