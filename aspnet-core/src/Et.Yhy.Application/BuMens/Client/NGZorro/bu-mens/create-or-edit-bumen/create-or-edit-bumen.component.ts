
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateBumenInput,BumenEditDto, BumenServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-bumen',
  templateUrl: './create-or-edit-bumen.component.html',
  styleUrls:[
	'create-or-edit-bumen.component.less'
  ],
})

export class CreateOrEditBumenComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: BumenEditDto=new BumenEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _bumenService: BumenServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._bumenService.getForEdit(this.id).subscribe(result => {
			this.entity = result.bumen;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateBumenInput();
		input.bumen = this.entity;

		this.saving = true;

		this._bumenService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
