let i = 0;
next();

function load_question(idx) {
    fetch(`/questions/${idx}`).then(q => {
        if (!q.ok) console.error("Hiba");
        else return q.json();
    }).then(q => show_question(q));
}

function show_question(question) {
    console.log(question);
    document.getElementById("question_text").innerText = question.question1;
    document.getElementById("answer1").innerText = question.answer1;
    document.getElementById("answer2").innerText = question.answer2;
    document.getElementById("answer3").innerText = question.answer3;
    document.getElementById("image1").src = "https://szoft1.comeback.hu/hajo/" + question.image;
}

function next() {
    i++;
    load_question(i);
}

function back() {
    i--
    load_question(i)
}