var jokes;

window.onload = download();

function download() {
    fetch("/jokes.json")
        .then(response => response.json()).then(data => completeDownload(data))
}
function completeDownload(d) {
    console.log("Success.");
    console.log(d)
    jokes = d;
    for (var i = 0; i < jokes.length;i++) {
        console.log(jokes[i].answer);
        var line = document.createElement("div");
        line.innerHTML = `<p>${jokes[i].question}</p><p>${jokes[i].answer}</p>`;
        document.body.appendChild(line);
    }
}