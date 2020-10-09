import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastrService } from "ngx-toastr";

export class AppErrorHandler implements ErrorHandler{
    constructor(@Inject(ToastrService) private toastrService: ToastrService,private ngZone : NgZone) { }
    handleError(error: any): void {
    
        this.ngZone.run(()=>{
        if(error.status == 404){
            console.log("404");
            this.toastrService.error("Not found!", "Error",{timeOut : 3000,closeButton : true});
        }else
            this.toastrService.error("Unexpected error occured!.", "Error", { timeOut: 3000 , closeButton : true});
    });
}

}
