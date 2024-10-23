mod display;
mod file_reader;

use std::{env, io, path::PathBuf};

use display::Display;
use file_reader::FileReader;

fn task_1() {
    let display1: Display = Display::new(50, 100, 300.0, String::from("display1"));
    let display2: Display = Display::new(20, 60, 400.0, String::from("display2"));
    let display3: Display = Display::new(140, 50, 500.0, String::from("display3"));

    display1.compare_with_monitor(&display2);
    display2.compare_with_monitor(&display3);
    display3.compare_with_monitor(&display1);
}

fn task_2_and_4() {
    let paths: Vec<PathBuf> = env::args().skip(1).map(PathBuf::from).collect();

    let data_list = FileReader::read_txt_in_text_data(&paths);

    for data in data_list {
        println!("{}", &data);
    }
}

fn main() {
    let mut choice: i32 = -1;
    let read_number = || {
        let mut input = String::new();
        io::stdin()
            .read_line(&mut input)
            .expect("Failed to read line");
        input
            .trim()
            .parse::<i32>()
            .expect("Please enter a valid number.")
    };
    while choice != 0 {
        println!("Enter a number of task (1-4)");

        choice = read_number();
        match choice {
            1 => task_1(),
            2 | 4 => task_2_and_4(),
            _ => println!("not a valid choice"),
        }
    }
}
