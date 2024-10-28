pub struct Display {
    width: i16,
    height: i16,
    ppi: f32,
    model: String,
}

impl Display {
    pub fn new(width: i16, height: i16, ppi: f32, model: String) -> Self {
        Display {
            width,
            height,
            ppi,
            model,
        }
    }

    fn get_area(&self) -> i16 {
        self.width * self.height
    }

    pub fn compare_size(&self, other_display: &Display) {
        let this_area = self.get_area();
        let other_area = other_display.get_area();

        println!(
            "Comparing size between {} and {}:",
            self.model, other_display.model
        );
        let comparison_result = this_area.cmp(&other_area);
        match comparison_result {
            std::cmp::Ordering::Less => println!(
                "{} is larger in size with an area of {}\n",
                self.model, this_area
            ),
            std::cmp::Ordering::Greater => println!(
                "{} is larger in size with an area of {}\n",
                other_display.model, other_area
            ),
            std::cmp::Ordering::Equal => println!(
                "Both {} and {} have the same size {}\n",
                self.model, other_display.model, this_area
            ),
        }
    }

    pub fn compare_sharpnees(&self, other_display: &Display) {
        println!(
            "Comparing sharpness between {} and {}:",
            self.model, other_display.model
        );
        let comparison_result = self.ppi.total_cmp(&other_display.ppi);
        match comparison_result {
            std::cmp::Ordering::Less => println!(
                "{} is larger in size with an ppi of {}\n",
                self.model, self.ppi
            ),
            std::cmp::Ordering::Greater => println!(
                "{} is larger in size with an ppi of {}\n",
                other_display.model, other_display.ppi
            ),
            std::cmp::Ordering::Equal => println!(
                "Both {} and {} have the same ppi {}\n",
                self.model, other_display.model, self.ppi
            ),
        }
    }

    pub fn compare_with_monitor(&self, other_display: &Display) {
        println!("--------------------------------------------------------------------------");
        println!(
            "\nComparing overall (size and sharpness) between {} and {}:\n",
            self.model, other_display.model
        );
        self.compare_size(other_display);
        self.compare_sharpnees(other_display);
        println!("--------------------------------------------------------------------------");
    }
}
