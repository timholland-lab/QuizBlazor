function checkAnswers() {

    var score = 0;

    // retrieve totalNumberQuestions from the html page
    var totalNumberQuestions = document.getElementById("count").innerHTML;

    // loop through each question
    for (z = 1; z <= totalNumberQuestions; z++) {

        var correctAnswers = "";
        var givenAnswers = "";

        //select all elements that have the question id in the name attr
        var result = document.querySelectorAll(`[name="${z}"]`);

        //if answer is correct, add to correctAnswers string. if user has answered correctly, add to givenAnswers string
        for (var i = 0; i < result.length; i++) {
            if (result[i].value == "Correct") {
                correctAnswers += result[i].dataset.answer + "<br>"
            }
            if (result[i].checked) {
                givenAnswers += result[i].dataset.answer + "<br>"
            }
        }

        // Display headings

        document.querySelector(`[data-CorrectAnswersHeading="${z}"]`).style.display = "inline";
        document.querySelector(`[data-GivenAnswers="${z}"]`).innerHTML = givenAnswers

        // Insert both correct answers and given answers for comparison
        document.querySelector(`[data-CorrectAnswers="${z}"]`).innerHTML = correctAnswers;
        document.querySelector(`[data-GivenAnswersHeading="${z}"]`).style.display = "inline";

        // space out
        var spaces = document.getElementsByClassName('spaces');
        for (var i = 0; i < spaces.length; i++) {
            spaces[i].style.display = "inline";
        }

        // tally up how many correct answers match the user's given answers
        if (correctAnswers === givenAnswers) {
            score++
        }

        //remove Check Answers button
        document.getElementById("checkAnswersBut").style.display = "none";

        event.preventDefault()
    }

    // display total score
    document.getElementById("score").innerHTML = "SCORE: " + score;
}     
