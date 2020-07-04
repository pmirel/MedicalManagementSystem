import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PatientsService } from '../patients.service';
import { Patient } from '../patients.models';
import { randomFill } from 'crypto';

@Component({
  selector: 'app-patients-edit',
  templateUrl: './patients-edit.component.html',
  styleUrls: ['./patients-edit.component.css']
})
export class PatientsEditComponent implements OnInit {

  private routerLink: string = '../list';

  private patientID: number;

  private isEdit: boolean = false;

  public formGroup: FormGroup;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private patientsService: PatientsService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.patientID = parseInt(this.route.snapshot.params['id']);

    if (this.patientID) {
      this.routerLink = '../../list';

      this.patientsService.getPatient(this.patientID).subscribe(res => {
        this.initForm(res);
        this.isEdit = true;
      });
    }
    else {
      this.initForm(<Patient>{});
    }
  }

  save() {
    Object.keys(this.formGroup.controls).forEach(control => {
      this.formGroup.get(control).markAsTouched();
    });

    if (this.formGroup.valid) {
      let patient = this.formGroup.value as Patient;
      patient.doctorId = 4;

      if (this.isEdit) {
        patient.id = this.patientID;

        this.patientsService.modifyPatient(patient).subscribe(res => {
          this.router.navigate(['/patients']);
        });
      } else {

        this.patientsService.savePatient(patient).subscribe(res => {
          this.router.navigate(['/patients']);
        });
      }
    }
  }

  initForm(patient: Patient) {
    this.formGroup = this.formBuilder.group({

      firstName: [patient.firstName, Validators.required],
      lastName: [patient.lastName, Validators.required],
      cnp: [patient.cnp, Validators.required],
      email: [patient.email, Validators.required],

    });
  }

}
