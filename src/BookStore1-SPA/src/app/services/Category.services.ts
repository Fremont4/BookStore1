import { NgModel } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

export class ConfirmationDialogServices {
    constructor(private modalService: NgbModal) {
        
    }
    public confirm (
        title: string,
        message: string,
        btnOkText: string = 'Ok',
        btnCancelText: string = 'Cancel',
        dialogSize: 'sm'|'lg' = 'sm'): Promise<boolean> {
        const modalRef = this.modalService.open(ConfirmationDialogComponent, { size: dialogSize });
        modalRef.componentInstance.title = title;
        modalRef.componentInstance.message = message;
        modalRef.componentInstance.btnOkText = btnOkText;
        modalRef.componentInstance.btnCancelText = btnCancelText;

    return modalRef.result;
    }
}