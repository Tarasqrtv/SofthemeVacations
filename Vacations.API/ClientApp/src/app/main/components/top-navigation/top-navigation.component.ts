import { Component, OnInit } from '@angular/core';
import { ImageService } from '../../services/image.service';
import { Routes, Router } from '@angular/router';

@Component({
  selector: 'app-top-navigation',
  templateUrl: './top-navigation.component.html',
  styleUrls: ['./top-navigation.component.scss']
})
export class TopNavigationComponent implements OnInit {

  imgUrl: string;

  constructor(private imgService: ImageService, private router: Router) { }

  ngOnInit() {
    this.imgService.getImgUrl().subscribe(
      response => { this.imgUrl = response; console.log(response); console.log(this.imgUrl); },
      () => this.imgUrl = "default");
  }
  viewdiv(id) {
    const el = document.getElementById(id);
    if (el.style.display === 'block') {
      el.style.display = 'none';

    } else {
      el.style.display = 'block';
    }
  }
  logout()
  {
    localStorage.setItem("token", "");
    localStorage.setItem("role", "");
    this.router.navigate(["/auth"])
  }
}
