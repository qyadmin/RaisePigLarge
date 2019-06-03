#pragma strict
#pragma downcast

var sceneCamera : Camera;

private var currentAnimation : String;

var dog : GameObject;
var cat : GameObject;
var turtle : GameObject;
var owl : GameObject;
var rat : GameObject;

var idleButton : Transform;
var talkButton : Transform;
var rollingButton : Transform;
var successButton : Transform;
var jumpButton : Transform;
var idle2Button : Transform;
var runButton : Transform;
var failureButton : Transform;
var sleepButton : Transform;
var walkButton : Transform;

var selectedButton : Transform;
private var selectedButtonScript : SelectedButton;

function Start () {
	dog.GetComponent.<Animation>().Play("Walk Dog");
	cat.GetComponent.<Animation>().Play("Walk Cat");
	turtle.GetComponent.<Animation>().Play("Walk Turtle");
	owl.GetComponent.<Animation>().Play("Walk Owl");
	rat.GetComponent.<Animation>().Play("Walk Rat");

	selectedButtonScript = selectedButton.GetComponent(SelectedButton);
}

function Update () {
	if(Input.GetMouseButtonDown(0)){
		var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
		if(Physics.Raycast(ray, hit)){;
			switch(hit.transform){
				case idleButton:
					if(currentAnimation != "Idle"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Idle Dog");
						cat.GetComponent.<Animation>().Blend("Idle Cat");
						turtle.GetComponent.<Animation>().Blend("Idle Turtle");
						owl.GetComponent.<Animation>().Blend("Idle Owl");
						rat.GetComponent.<Animation>().Blend("Idle Rat");
						selectedButton.position = idleButton.position;
						currentAnimation = "Idle";
					}
					break;
				case talkButton:
					if(currentAnimation != "Talk"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Talk Dog");
						cat.GetComponent.<Animation>().Blend("Talk Cat");
						turtle.GetComponent.<Animation>().Blend("Talk Turtle");
						owl.GetComponent.<Animation>().Blend("Talk Owl");
						rat.GetComponent.<Animation>().Blend("Talk Rat");
						selectedButton.position = talkButton.position;
						currentAnimation = "Talk";
					}
					break;
				case rollingButton:
					if(currentAnimation != "Rolling"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Rolling Dog");
						cat.GetComponent.<Animation>().Blend("Rolling Cat");
						turtle.GetComponent.<Animation>().Blend("Rolling Turtle");
						owl.GetComponent.<Animation>().Blend("Rolling Owl");
						rat.GetComponent.<Animation>().Blend("Rolling Rat");
						selectedButton.position = rollingButton.position;
						currentAnimation = "Rolling";
					}
					break;
				case successButton:
					if(currentAnimation != "Success"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Success Dog");
						cat.GetComponent.<Animation>().Blend("Success Cat");
						turtle.GetComponent.<Animation>().Blend("Success Turtle");
						owl.GetComponent.<Animation>().Blend("Success Owl");
						rat.GetComponent.<Animation>().Blend("Success Rat");
						selectedButton.position = successButton.position;
						currentAnimation = "Success";
					}
					break;
				case jumpButton:
					if(currentAnimation != "Jump"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent(JumpTest).enabled = true;
						cat.GetComponent(JumpTest).enabled = true;
						turtle.GetComponent(JumpTest).enabled = true;
						owl.GetComponent(JumpTest).enabled = true;
						rat.GetComponent(JumpTest).enabled = true;
						selectedButton.position = jumpButton.position;
						currentAnimation = "Jump";
					}
					break;
				case idle2Button:
					if(currentAnimation != "Idle 2"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Idle 2 Dog");
						cat.GetComponent.<Animation>().Blend("Idle 2 Cat");
						turtle.GetComponent.<Animation>().Blend("Idle 2 Turtle");
						owl.GetComponent.<Animation>().Blend("Idle 2 Owl");
						rat.GetComponent.<Animation>().Blend("Idle 2 Rat");
						selectedButton.position = idle2Button.position;
						currentAnimation = "Idle 2";
					}
					break;
				case runButton:
					if(currentAnimation != "Run"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Run Dog");
						cat.GetComponent.<Animation>().Blend("Run Cat");
						turtle.GetComponent.<Animation>().Blend("Run Turtle");
						owl.GetComponent.<Animation>().Blend("Run Owl");
						rat.GetComponent.<Animation>().Blend("Run Rat");
						selectedButton.position = runButton.position;
						currentAnimation = "Run";
					}
					break;
				case failureButton:
					if(currentAnimation != "Failure"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Failure Dog");
						cat.GetComponent.<Animation>().Blend("Failure Cat");
						turtle.GetComponent.<Animation>().Blend("Failure Turtle");
						owl.GetComponent.<Animation>().Blend("Failure Owl");
						rat.GetComponent.<Animation>().Blend("Failure Rat");
						selectedButton.position = failureButton.position;
						currentAnimation = "Failure";
					}
					break;
				case sleepButton:
					if(currentAnimation != "Sleep"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Sleep Dog");
						cat.GetComponent.<Animation>().Blend("Sleep Cat");
						turtle.GetComponent.<Animation>().Blend("Sleep Turtle");
						owl.GetComponent.<Animation>().Blend("Sleep Owl");
						rat.GetComponent.<Animation>().Blend("Sleep Rat");
						selectedButton.position = sleepButton.position;
						currentAnimation = "Sleep";
					}
					break;
				case walkButton:
					if(currentAnimation != "Walk"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						dog.GetComponent.<Animation>().Blend("Walk Dog");
						cat.GetComponent.<Animation>().Blend("Walk Cat");
						turtle.GetComponent.<Animation>().Blend("Walk Turtle");
						owl.GetComponent.<Animation>().Blend("Walk Owl");
						rat.GetComponent.<Animation>().Blend("Walk Rat");
						selectedButton.position = walkButton.position;
						currentAnimation = "Walk";
					}
					break;
			}
		}
	}
}

function BlendAllCharactersToZero(){
	BlendAllToZero(dog);
	BlendAllToZero(cat);
	BlendAllToZero(turtle);
	BlendAllToZero(owl);
	BlendAllToZero(rat);
	
	dog.GetComponent(JumpTest).enabled = false;
	cat.GetComponent(JumpTest).enabled = false;
	turtle.GetComponent(JumpTest).enabled = false;
	owl.GetComponent(JumpTest).enabled = false;
	rat.GetComponent(JumpTest).enabled = false;
}

function BlendAllToZero(character : GameObject){
	var animation = character.GetComponent.<Animation>();
	for(var state : AnimationState in animation){
		animation.Blend(state.name, 0);
	}
}