import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DoctorsService } from '../doctors.service';
import { Doctor, Speciality } from '../doctors.models';

@Component({
  selector: 'app-doctors-edit',
  templateUrl: './doctors-edit.component.html',
  styleUrls: ['./doctors-edit.component.css']
})
export class DoctorsEditComponent implements OnInit {

  private routerLink: string = '../list';

  private doctorID: number;

  private isEdit: boolean = false;

  public formGroup: FormGroup;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private doctorsService: DoctorsService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.doctorID = parseInt(this.route.snapshot.params['id']);

    if (this.doctorID) {
      this.routerLink = '../../list';

      this.doctorsService.getDoctor(this.doctorID).subscribe(res => {
        this.initForm(res);
        this.isEdit = true;
      });
    }
    else {
      this.initForm(<Doctor>{});
    }
  }

  save() {
    Object.keys(this.formGroup.controls).forEach(control => {
      this.formGroup.get(control).markAsTouched();
    });

    if (this.formGroup.valid) {
      let doctor = this.formGroup.value as Doctor;
      doctor.speciality = Speciality.Neurology

      if (this.isEdit) {
        doctor.id = this.doctorID;

        this.doctorsService.modifyDoctor(doctor).subscribe(res => {
          this.router.navigate(['/doctors']);
        });
      } else {

        this.doctorsService.saveDoctor(doctor).subscribe(res => {
          this.router.navigate(['/doctors']);
        });
      }
    }
  }

  initForm(doctor: Doctor) {
    this.formGroup = this.formBuilder.group({

      firstName: [doctor.firstName, Validators.required],
      lastName: [doctor.lastName, Validators.required]

    });
  }


}
