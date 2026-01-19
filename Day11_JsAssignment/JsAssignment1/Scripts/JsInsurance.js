/* Task 1 – Select by ID
Change the dashboard title text to “Customer Insurance Overview” */
document.getElementById("pageTitle").textContent="Customer Insurance Overview";



/* Task 2 - Select by Tag Name
Select all <li> elements and:
Add a border
Log the total number of customers */
const custlist=document.getElementsByTagName("li");
for(let c of custlist){
c.style.border="1px solid black";
}
console.log(custlist.length);



/* Task 3 - Select by Class Name
Select all .policy elements and:
Add highlight class
Change text color to blue */
const policylist=document.getElementsByClassName("policy");
for(let p of policylist){
    p.classList.add("highlight");
    p.style.color="blue";
}



/* Task 4 - Select using CSS Selectors
Select the first customer only
Select all customers
Mark the last customer as active */
const firstcust=document.querySelector(".customer:first-child");
console.log(firstcust);
const allcust=document.querySelectorAll("customer");
console.log(allcust);
const lastcust=document.querySelector(".customer:last-child");
console.log(lastcust);
lastcust.classList.add("active");



/* Task 5 - HTML Object Collections
Using document collections:
Count number of forms
Get number of images
Change text of all links to “More Info” */
console.log("Number of forms",document.forms.length);
console.log("Number of images:",document.images.length);
for(let i of document.links){
    i.innerHTML="More Info";
}



/* Task 6 - Add a new customer dynamically and observe:
Which selections update automatically?
Which don’t? */
const newcust = document.createElement("li");
newcust.className = "customer";
newcust.textContent = "Sanvi - Health";
document.getElementById("customerList").appendChild(newcust);
//Observation:
// getElementsByTagName / getElementsByClassName : auto update because those methods return a live HTMLCollection
// querySelectorAll : does NOT auto update because it returns a static NodeList




/* Task 7 - Attribute-Based Selection
Select only input fields whose type is "text" using CSS selectors and:
Add a yellow background
Add placeholder text: "Enter Full Name" */
const inp=document.querySelectorAll('input[type="text"]');
for(let i of inp){
    i.style.backgroundColor="yellow";
    i.placeholder="Enter Full Name";
}



/* Task 8 - Multiple Class Selection
Select all elements that have both customer and active classes and:
Change text color to dark green
Add text (Priority Customer) at the end */
const cust=document.getElementsByClassName("customer");
for(let c of cust){
    c.style.color="darkgreen";
    c.textContent+=" -(Priority Customer)";
}



/* Task 9 – Descendant vs Child Selector
Select all <li> elements inside #customerList using a descendant selector
Select only direct child <li> using a child selector
Log the difference in console. */
const descendantli=document.querySelectorAll("#customerList li");
const directchildli=document.querySelectorAll("#customerList > li");
console.log("Difference:",descendantli.length-directchildli.length);




/* Task 10 - Even / Odd Selection (CSS Pseudo Selectors)
Using querySelectorAll():
Highlight even customers in light gray
Highlight odd customers in light blue */
document.querySelectorAll("#customerList li:nth-child(even)")
.forEach(li => {
    li.style.backgroundColor = "lightgray";
  });
document.querySelectorAll("#customerList li:nth-child(odd)")
.forEach(li => {
    li.style.backgroundColor = "lightblue";
  });



/* Task 11 - Form Elements Collection
Using HTML form object model:
Access the enquiry form
Log all input field names
Disable the submit button */
const enqform=document.forms['enquiryForm'];
for(let e of enqform.elements){
    console.log(e.name);
}
enqform.querySelector("button[type='submit']").disabled=true;




/* Task 12 - NodeList vs HTMLCollection
Select policies using:
getElementsByClassName
querySelectorAll
Dynamically add a new policy
Observe which collection updates automatically */
const htmlcol=document.getElementsByClassName("policy");
const nodelistcol=document.querySelectorAll(".policy");
const newpolicy=document.createElement("p");
newpolicy.className="policy";
newpolicy.textContent="Disability Insurance";
document.body.appendChild(newpolicy);
console.log("HTML Collection Length",htmlcol.length);
console.log("NodeList Collection",nodelistcol.length);
// HTMLCollection is always a live collection and it will update automatically
// NodeList is most often a static collection which will not auto update



/* Task 13 - Text Content Filtering
Select all customers and:
Highlight customers whose policy includes "Life"
Hide customers whose policy includes "Vehicle" */
const customers=document.querySelectorAll(".customer");
for(let c of customers){
    const text=c.textContent;
    if(text.includes('Life')){
        c.classList.add("highlight");
    }
    if(text.includes('Vehicle')){
        c.style.display="none";
    }
}



/* Task 14 - Closest & Parent Traversal
When clicking any customer <li>:
Find the nearest <ul>
Add a border to it */
const custom=document.querySelectorAll(".customer");
for(let c of custom){
    c.addEventListener("click",()=>{
        const parentul=c.closest("ul");
        parentul.style.border= "5px solid pink";
    })
}



/* Task 15 – Complex Selector Challenge Select:
All policy <p> elements except the first one and:
Change font style to italic
Prefix text with "✔" */
const policyelement=document.querySelectorAll("p.policy:not(:first-of-type)");
for(let p of policyelement){
    p.style.fontStyle="italic";
    p.insertAdjacentText("afterbegin", "✔ ");
}
