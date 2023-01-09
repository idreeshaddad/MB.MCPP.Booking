import { Component } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent {

  slides = [
    {img: "../../assets/imgs/item.png"},
    {img: "../../assets/imgs/user.png"},
    {img: "../../assets/imgs/item.png"},
    {img: "../../assets/imgs/user.png"},
    {img: "../../assets/imgs/item.png"},
    {img: "../../assets/imgs/user.png"},
    {img: "../../assets/imgs/item.png"},
    {img: "../../assets/imgs/user.png"}
  ];
  slideConfig = {"slidesToShow": 4, "slidesToScroll": 4};
  
  addSlide() {
    console.log('addSlide initialized');
  }
  
  removeSlide() {
    this.slides.length = this.slides.length - 1;
  }
  
  slickInit(e: any) {
    console.log('slick initialized');
  }
  
  breakpoint(e: any) {
    console.log('breakpoint');
  }
  
  afterChange(e: any) {
    console.log('afterChange');
  }
  
  beforeChange(e: any) {
    console.log('beforeChange');
  }
}
