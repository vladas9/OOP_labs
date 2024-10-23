mod display;

use display::Display;

fn task_1() {
    let display1: Display = Display::new(50, 100, 300.0, String::from("display1"));
    let display2: Display = Display::new(20, 60, 400.0, String::from("display2"));
    let display3: Display = Display::new(140, 50, 500.0, String::from("display3"));

    display1.compare_with_monitor(&display2);
    display2.compare_with_monitor(&display3);
    display3.compare_with_monitor(&display1);
}

fn main() {
    task_1();
}
